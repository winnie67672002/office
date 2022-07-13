export class UserGroupFunction {
  CId: number;
  CName: string;
  FunctionLv1: UserGroupFunctionV1[];
}

export class UserGroupFunctionV1 {
  CId: number;
  CName: string;
  FunctionLv2: UserGroupFunctionV2[];
}

export class UserGroupFunctionV2 {
  CId: number;
  CName: string;
  Authority: Authority[];
}

export class Authority {
  CId: number;
  CName: string;
  IsChecked: boolean;
}
