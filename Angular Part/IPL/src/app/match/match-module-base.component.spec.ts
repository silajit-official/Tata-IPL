import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MatchModuleBaseComponent } from './match-module-base.component';

describe('MatchModuleBaseComponent', () => {
  let component: MatchModuleBaseComponent;
  let fixture: ComponentFixture<MatchModuleBaseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MatchModuleBaseComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MatchModuleBaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
