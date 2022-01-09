import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MediaUpdateComponent } from './media-update.component';

describe('MediaUpdateComponent', () => {
  let component: MediaUpdateComponent;
  let fixture: ComponentFixture<MediaUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MediaUpdateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MediaUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
