import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MediaCreateComponent } from './media-create.component';

describe('MediaCreateComponent', () => {
  let component: MediaCreateComponent;
  let fixture: ComponentFixture<MediaCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MediaCreateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MediaCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
