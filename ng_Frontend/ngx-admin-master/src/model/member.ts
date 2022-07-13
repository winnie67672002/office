export class Member {
  CId = null;
  CMainEmail: string;
  CMainPhone: string;
  CStatus: number;
  CCreateDt: Date;
  CTags = [] as CTag[];
}


export class CTag {
  CId = null;
  CName: string;
  COptions: string;
  COptionValue: string;
  IsEdit = false;
}
