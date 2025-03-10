import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { RegistrationService } from './services/api.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import {
  FormArray,
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CommonModule } from '@angular/common';
import { mergeMap, Observable, startWith, Subject } from 'rxjs';
import { ReverseStringPipe } from './pipes/reverse.pipe';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ReactiveFormsModule, CommonModule, ReverseStringPipe],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit {
  public registrationForm: FormGroup;
  public socialMediaPlatforms: any[] = [];
  public reload$ = new Subject();
  public registrations$: Observable<any[]>;

  constructor(
    private fb: FormBuilder,
    private readonly service: RegistrationService
  ) {
    this.registrationForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      socialSkills: this.fb.array([]),
      socialMediaAddresses: this.fb.array([]),
    });

    this.registrations$ = this.reload$.pipe(
      startWith(null),
      mergeMap(() => this.service.getRegistrations())
    );
  }

  ngOnInit() {
    this.service.getSocialMediaPlatforms().subscribe((data) => {
      this.socialMediaPlatforms = data;
      for (var idx = 0; idx < this.socialMediaPlatforms.length; idx++) {
        this.socialMediaAddresses?.push(
          this.fb.group({
            platformId: this.socialMediaPlatforms[idx].id,
            address: [
              '',
              [
                Validators.pattern(
                  this.socialMediaPlatforms[idx].validationRegex
                ),
              ],
            ],
          })
        );
      }
    });
  }

  get socialSkills() {
    return this.registrationForm.get('socialSkills') as FormArray;
  }

  get socialMediaAddresses() {
    return this.registrationForm.get('socialMediaAddresses') as FormArray;
  }

  addSkill() {
    if (this.socialSkills) {
      this.socialSkills.push(this.fb.control(''));
    }
  }

  onSubmit() {
    if (this.registrationForm) {
      this.service
        .addRegistration(this.registrationForm.value)
        .subscribe(() => {
          if (this.registrationForm) {
            this.registrationForm.reset();
            this.reload$.next(null);
          }
        });
    }
  }
}
