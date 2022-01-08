import { Overlay, OverlayRef } from '@angular/cdk/overlay';
import { ComponentPortal } from '@angular/cdk/portal';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SpinnerOverlayComponent } from '../components/spinner/spinner-overlay/spinner-overlay.component';
    
@Injectable({
    providedIn: 'root'
})
export class SpinnerOverlayService { 
  private overlayRef: OverlayRef;
    
  constructor(private overlay: Overlay, private http: HttpClient) { }

  public show(message = ''): void {
    // Returns an OverlayRef (which is PortalHost)
    if (!this.overlayRef) {
        this.overlayRef = this.overlay.create();
    }
    // Create ComponentPortal that can be attached to a PortalHost
    const spinnerOverlayPortal = new ComponentPortal(SpinnerOverlayComponent);
    this.overlayRef.attach(spinnerOverlayPortal); // Attach ComponentPortal
  }

  public hide(): void {
    if (!!this.overlayRef) {
        this.overlayRef.detach();
    }
  }
}
