import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DefaultTagAutoCompleteComponent } from './default-tag-auto-complete.component';

describe('DefaultTagAutoCompleteComponent', () => {
  let component: DefaultTagAutoCompleteComponent;
  let fixture: ComponentFixture<DefaultTagAutoCompleteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DefaultTagAutoCompleteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DefaultTagAutoCompleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
