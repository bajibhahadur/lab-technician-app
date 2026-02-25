import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LabService, Patient, TestType, TestResult } from '../services/lab.service';

@Component({
  selector: 'app-test-entry',
  templateUrl: './test-entry.component.html'
})
export class TestEntryComponent implements OnInit {
  patient: Patient | null = null;
  testTypes: TestType[] = [];
  selectedTestType: TestType | null = null;
  resultValues: { [parameterId: number]: string } = {};
  message = '';
  submitting = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private labService: LabService
  ) {}

  ngOnInit(): void {
    const patientId = Number(this.route.snapshot.paramMap.get('id'));
    this.labService.getPatients().subscribe({
      next: (patients) => {
        this.patient = patients.find(p => p.id === patientId) || null;
      }
    });
    this.labService.getTestTypes().subscribe({
      next: (types) => this.testTypes = types
    });
  }

  selectTestType(testType: TestType): void {
    this.selectedTestType = testType;
    this.resultValues = {};
    testType.parameters.forEach(p => this.resultValues[p.id] = '');
  }

  submitResults(): void {
    if (!this.patient || !this.selectedTestType) return;
    const items = this.selectedTestType.parameters.map(p => ({
      testParameterId: p.id,
      value: this.resultValues[p.id] || ''
    }));

    const testResult: TestResult = {
      patientId: this.patient.id!,
      testTypeId: this.selectedTestType.id,
      items: items
    };

    this.submitting = true;
    this.labService.createTestResult(testResult).subscribe({
      next: (result) => {
        this.submitting = false;
        this.message = 'Test results saved successfully!';
        setTimeout(() => {
          this.router.navigate(['/report', this.patient!.id]);
        }, 1500);
      },
      error: (err) => {
        this.submitting = false;
        console.error(err);
        this.message = 'Error saving test results.';
      }
    });
  }

  goBack(): void {
    this.router.navigate(['/patients']);
  }
}
