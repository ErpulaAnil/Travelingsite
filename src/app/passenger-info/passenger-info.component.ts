import { Component, OnInit } from '@angular/core';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-passenger-info',
  templateUrl: './passenger-info.component.html',
  styleUrls: ['./passenger-info.component.css']
})
export class PassengerInfoComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  alertConfirmation(){
    Swal.fire({
      title: 'Are you sure?',
      text: 'This process is irreversible.',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, go ahead.',
      cancelButtonText: 'No, let me think'
    }).then((result) => {
      if (result.value) {
        Swal.fire(
          'Removed!',
          'Booking deleted successfully',
          'success'
        )
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        Swal.fire(
          'Cancelled',
          'Failed to delete',
          'error'
        )
      }
    })
  }  
}
