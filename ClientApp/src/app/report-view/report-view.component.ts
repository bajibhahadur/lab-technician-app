import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LabService, TestResult, Patient } from '../services/lab.service';

@Component({
  selector: 'app-report-view',
  templateUrl: './report-view.component.html',
  styleUrls: ['./report-view.component.css']
})
export class ReportViewComponent implements OnInit {
  patient: Patient | null = null;
  testResults: TestResult[] = [];
  selectedResult: TestResult | null = null;

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
    this.labService.getTestResultsByPatient(patientId).subscribe({
      next: (results) => {
        this.testResults = results;
        if (results.length > 0) this.selectedResult = results[0];
      }
    });
  }

  selectResult(result: TestResult): void {
    this.selectedResult = result;
  }

  printReport(): void {
    window.print();
  }

  goBack(): void {
    this.router.navigate(['/patients']);
  }

  enterNewTest(): void {
    if (this.patient?.id) {
      this.router.navigate(['/test-entry', this.patient.id]);
    }
  }
}
