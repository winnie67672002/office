import { Injectable } from '@angular/core';
import { NbToastrService } from '@nebular/theme';

@Injectable({
  providedIn: 'root',
})
export class MessageService {
  showErrorMSG(content: string, canDuplicates: boolean = false) {
    this.toastrService.show(
      content,
      '錯誤', { status: 'danger', preventDuplicates: !canDuplicates });
  }
  showSucessMSG(content: string, canDuplicates: boolean = false) {
    this.toastrService.show(
      content,
      '成功', { status: 'success', preventDuplicates: !canDuplicates });
  }
  showErrorMSGs(content: string[], canDuplicates: boolean = false) {
    this.toastrService.show(
      content.map(x => x).join('\n'),
      '錯誤', { status: 'danger', preventDuplicates: !canDuplicates });
  }
  constructor(
    private toastrService: NbToastrService,
  ) {

  }
}
