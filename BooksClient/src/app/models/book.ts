import { Guid } from 'guid-typescript';
import { KeyValue } from './keyvalue';

export class Book {
  id?: Guid;
  name?: string;
  author?: KeyValue;
  notes?: string;
  status?: KeyValue;
  genre?: KeyValue;
}
