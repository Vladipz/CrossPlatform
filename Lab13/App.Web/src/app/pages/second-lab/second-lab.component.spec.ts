import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SecondLabComponent } from './second-lab.component';

describe('SecondLabComponent', () => {
  let component: SecondLabComponent;
  let fixture: ComponentFixture<SecondLabComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SecondLabComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SecondLabComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
