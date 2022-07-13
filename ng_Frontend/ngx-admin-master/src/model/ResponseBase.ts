export class ResponseBase<T> {
  PageSize: number;
  PageNum: number;
  TotalPages: number;
  TotalItems: number;
  Entries: T;
  Message: string;
  StatusCode: number;
}
