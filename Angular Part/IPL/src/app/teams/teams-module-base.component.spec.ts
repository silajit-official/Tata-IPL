import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TeamsModuleBaseComponent } from './teams-module-base.component';

describe('TeamsModuleBaseComponent', () => {
  let component: TeamsModuleBaseComponent;
  let fixture: ComponentFixture<TeamsModuleBaseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TeamsModuleBaseComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TeamsModuleBaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
