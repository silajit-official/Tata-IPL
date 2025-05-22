import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayersModuleBaseComponent } from './players-module-base.component';

describe('PlayersModuleBaseComponent', () => {
  let component: PlayersModuleBaseComponent;
  let fixture: ComponentFixture<PlayersModuleBaseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PlayersModuleBaseComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PlayersModuleBaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
