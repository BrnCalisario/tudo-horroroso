import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewRecipePageComponent } from './view-recipe-page.component';

describe('ViewRecipePageComponent', () => {
  let component: ViewRecipePageComponent;
  let fixture: ComponentFixture<ViewRecipePageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ViewRecipePageComponent]
    });
    fixture = TestBed.createComponent(ViewRecipePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
