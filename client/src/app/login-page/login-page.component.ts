import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms'
import { Router } from '@angular/router';
import { catchError } from 'rxjs/operators';
import { AuthService } from '../auth/auth.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {
  loginForm: FormGroup;
  error?: string

  constructor(
    formBuilder: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    this.loginForm = formBuilder.group({
      email: '',
      password: ''
    })
  }

  navigateToAuction() {
    this.router.navigate(['auction'])
  }

  ngOnInit(): void {
    if (this.authService.isAuthenticated()) {
      this.navigateToAuction()
    }
  }

  onSubmit() {
    const { email, password } = this.loginForm.value

    this.authService.login(email, password)
      .subscribe(() => {
        this.navigateToAuction()
      }, err => {
        this.error = 'Usuário ou senha inválidos'
      })
  }

}
