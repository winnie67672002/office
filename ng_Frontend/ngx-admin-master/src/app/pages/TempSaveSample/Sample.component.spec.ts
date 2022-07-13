import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TempSaveSampleComponent } from './Sample.component';

describe('SampleComponent', () => {
  let component: TempSaveSampleComponent;
  let fixture: ComponentFixture<TempSaveSampleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TempSaveSampleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TempSaveSampleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
