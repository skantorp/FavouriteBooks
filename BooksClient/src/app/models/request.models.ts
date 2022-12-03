import { Guid } from 'guid-typescript';

export class UpdateBookModel {
  id?: Guid;
  name!: string;
  authorId?: Guid;
  authorName?: string;
  notes?: string;
  statusId!: Guid;
  genreId!: Guid;
}
