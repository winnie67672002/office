import { FunctionModel } from './../../../model/function';
import { UserGroupFunction } from '../../../model/userGroupFunction';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { UserGroup } from '../../../model/userGroup';
import { User } from '../../../model/user';
import { Menu } from '../../../model/menu';
import { UserLog } from '../../../model/userLog';
import { RefBase } from '../../../model/refBase';
import { Tag } from '../../../model/tag';
import { Member } from '../../../model/member';
import { MemberTag } from '../../../model/memberTag';
import { Task } from '../../../model/task';


@Injectable({
  providedIn: 'root',
})
export class SharedObservable {

  private Menu = new BehaviorSubject({} as Menu);
  private User = new BehaviorSubject([] as User[]);
  private UserGroup = new BehaviorSubject([] as UserGroup[]);
  private UserGroupFunction = new BehaviorSubject({} as UserGroupFunction);
  private UserLog = new BehaviorSubject([] as UserLog[]);
  private FunctionModel = new BehaviorSubject([] as FunctionModel[]);
  private RefBase = new BehaviorSubject([] as RefBase[]);
  private Tag = new BehaviorSubject([] as Tag[]);
  private Member = new BehaviorSubject([] as Member[]);
  private MemberTag = new BehaviorSubject([] as MemberTag[]);
  private Task = new BehaviorSubject({} as Task);

  SharedMenu = this.Menu.asObservable();
  SharedUser = this.User.asObservable();
  SharedUserGroup = this.UserGroup.asObservable();
  SharedUserGroupFunction = this.UserGroupFunction.asObservable();
  SharedUserLog = this.UserLog.asObservable();
  SharedFunctionModel = this.FunctionModel.asObservable();
  SharedRefBase = this.RefBase.asObservable();
  SharedTag = this.Tag.asObservable();
  SharedMember = this.Member.asObservable();
  SharedMemberTag = this.MemberTag.asObservable();
  SharedTask = this.Task.asObservable();

  SetMenu(Data: Menu) {
    this.Menu.next(Data);
  }
  SetUser(Data: User[]) {
    this.User.next(Data);
  }
  SetUserGroup(Data: UserGroup[]) {
    this.UserGroup.next(Data);
  }
  SetUserGroupFunction(Data: UserGroupFunction) {
    this.UserGroupFunction.next(Data);
  }
  SetUserLog(Data: UserLog[]) {
    this.UserLog.next(Data);
  }
  SetFunctionModel(Data: FunctionModel[]) {
    this.FunctionModel.next(Data);
  }
  SetRefBase(Data: RefBase[]) {
    this.RefBase.next(Data);
  }
  SetTag(Data: Tag[]) {
    this.Tag.next(Data);
  }
  SetMember(Data: Member[]) {
    this.Member.next(Data);
  }
  SetMemberTag(Data: MemberTag[]) {
    this.MemberTag.next(Data);
  }
  SetTask(Data: Task) {
    this.Task.next(Data);
  }

}
