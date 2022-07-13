export class Tag {
  CId = null;
  CName: string;
  CCreateDt: Date;
  CStatus: number;
  COptions: string;
  CIsDefaultKey: boolean;
  IsEdit = false;
}

export class AutocompleteTag {
  CTagValue: string;
  CTagKeyId: number;
}

