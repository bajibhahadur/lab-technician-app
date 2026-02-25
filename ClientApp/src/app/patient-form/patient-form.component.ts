import { Component, OnInit } from '@angular/core';
import { LabService, Patient } from '../services/lab.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-patient-form',
  templateUrl: './patient-form.component.html'
})
export class PatientFormComponent implements OnInit {
  patients: Patient[] = [];
  newPatient: Patient = { name: '', age: 0, gender: 'Male' };
  showForm = false;
  message = '';

  constructor(private labService: LabService, private router: Router) {}

  ngOnInit(): void {
    this.loadPatients();
  }

  loadPatients(): void {
    this.labService.getPatients().subscribe({
      next: (patients) => this.patients = patients,
      error: (err) => console.error(err)
    });
  }

  toggleForm(): void {
    this.showForm = !this.showForm;
    this.newPatient = { name: '', age: 0, gender: 'Male' };
    this.message = '';
  }

  savePatient(): void {
    if (!this.newPatient.name || !this.newPatient.age || !this.newPatient.gender) {
      this.message = 'Please fill all required fields.';
      return;
    }
    this.labService.createPatient(this.newPatient).subscribe({
      next: (patient) => {
        this.patients.unshift(patient);
        this.showForm = false;
        this.message = 'Patient registered successfully!';
        setTimeout(() => this.message = '', 3000);
      },
      error: (err) => console.error(err)
    });
  }

  enterTest(patientId: number): void {
    this.router.navigate(['/test-entry', patientId]);
  }

  viewReports(patientId: number): void {
    this.router.navigate(['/report', patientId]);
  }
}
