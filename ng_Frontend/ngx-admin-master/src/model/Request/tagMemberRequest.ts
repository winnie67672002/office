import { Page } from '../page';

export class TagMemberFilterRequest extends Page {
  Filter = [] as TagMemberFilter[];
}

export class TagMemberAddRequest {
  Filter = [] as TagMemberFilter[];
  Tags = [] as TagMemmberAdd[];
}

export class TagMemberFilter {
  MainOperator: number;
  DataType: number;
  TagId: number;
  TagName: string;
  SubOperator: number;
  Values = [] as string[];
}

export class TagMemmberAdd {
  CTagName: string;
  CTagValue: string;
  CTagKeyId: number;
}

