import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'ngx-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.scss']
})
export class LogoutComponent implements OnInit {

  constructor(
    private router: Router
  ) { }

  ngOnInit(): void {
    localStorage.setItem('cdp_token', '');
    localStorage.setItem('cdp_buId', '');
    localStorage.setItem('cdp_allow', '');
    this.router.navigateByUrl('login');
  }

}
