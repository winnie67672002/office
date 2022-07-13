import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TagInputDirectiveComponent } from './tag-input-directive.component';

describe('TagInputDirectiveComponent', () => {
  let component: TagInputDirectiveComponent;
  let fixture: ComponentFixture<TagInputDirectiveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TagInputDirectiveComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TagInputDirectiveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
