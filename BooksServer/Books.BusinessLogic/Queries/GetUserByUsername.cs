using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Books.BusinessLogic.DTOs;
using Books.DataAccessLayer.Entities;
using Books.DataAccessLayer.Interfaces;
using MediatR;

namespace Books.BusinessLogic.Queries
{
	public class GetUserByUsername : IRequest<UserDTO>
	{
		public string Username { get; set; }
	}

	public class GetUserByUsernameHandler : IRequestHandler<GetUserByUsername, UserDTO>
	{
		private readonly IRepository<User> _userRepository;
		private readonly IMapper _mapper;

		public GetUserByUsernameHandler(IRepository<User> userRepository, IMapper mapper)
		{
			_userRepository = userRepository;
			_mapper = mapper;
		}

		public async Task<UserDTO> Handle(GetUserByUsername request, CancellationToken cancellationToken)
		{
			var user = await _userRepository.GetOne(x => x.Username == request.Username);
			return _mapper.Map<UserDTO>(user);
		}
	}
}
