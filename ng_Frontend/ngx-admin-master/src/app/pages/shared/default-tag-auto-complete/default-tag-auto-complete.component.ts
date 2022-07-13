import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { ShareRequest } from '../../../../model/Request/shareRequest';
import { AutocompleteTag } from '../../../../model/tag';
import { TagService } from '../../../services/tag.service';

@Component({
  selector: 'ngx-default-tag-auto-complete',
  templateUrl: './default-tag-auto-complete.component.html',
  styleUrls: ['./default-tag-auto-complete.component.scss']
})
export class DefaultTagAutoCompleteComponent implements OnInit {

  @Input() IsAutocomplete = true;
  @Input() IsDefault = false;
  @Output() OutputTag = new EventEmitter();

  @ViewChild('autoInput') input;

  constructor(
    private tagService: TagService
  ) { }

  request = new ShareRequest();
  options = [] as string[];
  filteredOptions$: Observable<string[]>;
  autocompleteTag = [] as AutocompleteTag[];

  isAutocomplete = false;
  tagValue = '';

  ngOnInit(): void {

  }

  private filter(value: string): string[] {
    const filterValue = value.toLowerCase();
    return this.options.filter(optionValue => optionValue.toLowerCase().includes(filterValue));
  }

  getFilteredOptions(value: string): Observable<string[]> {
    return of(value).pipe(
      map(filterString => this.filter(filterString)),
    );
  }

  onAutocompleteChange() {
    if (this.IsAutocomplete === false) {
      return;
    }
    this.request.CName = this.tagValue;
    if (this.isAutocomplete === false) {
      this.isAutocomplete = true;
      setTimeout(() => { this.getAutocomplete(); }, 100);
    }
  }

  getAutocomplete() {
    this.request.IsDefault = this.IsDefault;
    this.tagService.getAutocompleteList(this.request).subscribe(res => {
      this.autocompleteTag = res.Entries;
      this.options = [...this.autocompleteTag.map(x => x.CTagValue)];
      this.filteredOptions$ = this.getFilteredOptions(this.input.nativeElement.value);

      const result = new AutocompleteTag();
      result.CTagKeyId = 0;
      result.CTagValue = this.tagValue;
      this.OutputTag.emit(result);

      this.isAutocomplete = false;
    });
  }

  onAutocompleteSelectionChange($event) {
    this.filteredOptions$ = this.getFilteredOptions($event);
    const tag = this.autocompleteTag.find(x => x.CTagValue === $event);

    if (tag !== undefined) {
      const result = new AutocompleteTag();
      result.CTagKeyId = tag.CTagKeyId;
      result.CTagValue = tag.CTagValue;
      this.OutputTag.emit(result);
    }
  }

}
