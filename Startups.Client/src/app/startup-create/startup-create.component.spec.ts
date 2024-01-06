import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StartupCreateComponent } from './startup-create.component';

describe('StartupCreateComponent', () => {
  let component: StartupCreateComponent;
  let fixture: ComponentFixture<StartupCreateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StartupCreateComponent]
    });
    fixture = TestBed.createComponent(StartupCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
