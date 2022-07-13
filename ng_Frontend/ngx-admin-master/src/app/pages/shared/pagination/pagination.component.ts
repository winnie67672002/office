import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'ngx-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.scss']
})
export class PaginationComponent implements OnInit {

  @Output() PageChange = new EventEmitter();
  @Input() Page: number;
  @Input() PageSize: number;
  @Input() CollectionSize: number;

  constructor() { }

  ngOnInit(): void {
  }

  pageChange() {
    this.PageChange.emit(this.Page);
  }

}
