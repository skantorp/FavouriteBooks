import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthResult } from 'src/app/models/auth.result';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  submitted = false;
  wrongCredentials = false;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit() {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  login() {
    this.submitted = true;
    const val = this.loginForm.value;

    if (val.username && val.password) {
      this.authService.login(val.username, val.password).subscribe((result) => {
        if ((result as AuthResult).success) {
          console.log('User is logged in');
          this.router.navigateByUrl('/');
        } else {
          this.wrongCredentials = true;
        }
      });
    }
  }
}
