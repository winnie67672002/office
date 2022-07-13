import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'getStatusName' })
export class StatusPipe implements PipeTransform {
  transform(value: number): any {
    if (value === 0) {
      return '停用';
    } else if (value === 1) {
      return '啟用';
    } else if (value === 9) {
      return '刪除';
    }
  }
}

@Pipe({ name: 'getDefaultKeyName' })
export class DefaultKeyPipe implements PipeTransform {
  transform(value: boolean): any {
    if (value) {
      return '是';
    } else {
      return '否';
    }
  }
}

@Pipe({ name: 'getTaskStatusName' })
export class TaskStatusPipe implements PipeTransform {
  transform(value: number): any {
    if (value === 0) {
      return '處理完成';
    } else if (value === 1) {
      return '等待中';
    } else if (value === 2) {
      return '處理中';
    } else if (value === 3) {
      return '資料異常';
    }
  }
}


@Pipe({ name: 'getTaskLogStatusName' })
export class TaskLogStatusPipe implements PipeTransform {
  transform(value: number): any {
    if (value === 0) {
      return '未處理';
    } else if (value === 1) {
      return '已處理';
    }
  }
}
