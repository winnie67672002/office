import { Page } from '../page';
export class ShareRequest extends Page {
  CName = '';
  CStatus = -1;
  CId: number;
  CUserName = '';
  CUserId = '';
  DateStart: Date;
  DateEnd: Date;
  FunctionId = -1;
  CFunctionId: number;
  CMemberId: number;
  RefBaseInfoId: number;
  RefBaseTaskStatus = -1;
  CRefBaseTaskId: number;
  CTagId: number;
  CTagName: string;
  File: any;
  IsDefault: boolean;
}

