export class Task {
  InfoId: number;
  InfoName: string;
  List = [] as TaskDetail[];
}

export class TaskDetail {
  CId: number;
  CName: string;
  CMemberCount: number;
  CTagCount: number;
  CCreator: string;
  CEffectiveDt: Date;
  CStatus: number;
}


export class TaskLog {
  TaskId: number;
  TaskName: string;
  List = [] as TaskLogDetail[];
}

export class TaskLogDetail {
  CId: number;
  CEmail: string;
  CPhone: string;
  CRefData: string;
  CRemark: string;
  CCreateDt: Date;
  CStatus: number;
}

