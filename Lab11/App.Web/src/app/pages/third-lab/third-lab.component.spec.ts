import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ThirdLabComponent } from './third-lab.component';

describe('ThirdLabComponent', () => {
  let component: ThirdLabComponent;
  let fixture: ComponentFixture<ThirdLabComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ThirdLabComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ThirdLabComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
