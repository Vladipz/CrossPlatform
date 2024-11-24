import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FirstLabComponent } from './first-lab.component';

describe('FirstLabComponent', () => {
  let component: FirstLabComponent;
  let fixture: ComponentFixture<FirstLabComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FirstLabComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FirstLabComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
