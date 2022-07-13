export class MenuModel {
  CId: number;
  CName: string;
  CParentId: number;
  CPageUrl: string;
  CIsMenu: boolean;
  CMenuIndex: number;
  CCssStyle: string;
  CStatus: number;
  CIsDelete: boolean;
  CCompetenceType: number;
  CFlowId: number;
  Child: MenuModel[];
}


export class Menu {
  Menu: MenuModel[];
}


export class MenuAllow {
  CPageUrl: string;
  CCompetenceType: number;
}
