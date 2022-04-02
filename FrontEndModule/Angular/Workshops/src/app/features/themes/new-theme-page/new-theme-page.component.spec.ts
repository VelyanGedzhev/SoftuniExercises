import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewThemePageComponent } from './new-theme-page.component';

describe('NewThemePageComponent', () => {
  let component: NewThemePageComponent;
  let fixture: ComponentFixture<NewThemePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewThemePageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewThemePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
