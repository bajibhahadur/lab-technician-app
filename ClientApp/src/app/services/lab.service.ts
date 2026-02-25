import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Patient {
  id?: number;
  name: string;
  age: number;
  gender: string;
  date?: string;
}

export interface TestParameter {
  id: number;
  testTypeId: number;
  name: string;
  unit: string;
  referenceRange: string;
}

export interface TestType {
  id: number;
  name: string;
  parameters: TestParameter[];
}

export interface TestResultItem {
  id?: number;
  testResultId?: number;
  testParameterId: number;
  value: string;
  testParameter?: TestParameter;
}

export interface TestResult {
  id?: number;
  patientId: number;
  testTypeId: number;
  testDate?: string;
  patient?: Patient;
  testType?: TestType;
  items: TestResultItem[];
}

@Injectable({ providedIn: 'root' })
export class LabService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}

  getPatients(): Observable<Patient[]> {
    return this.http.get<Patient[]>(this.baseUrl + 'api/patients');
  }

  createPatient(patient: Patient): Observable<Patient> {
    return this.http.post<Patient>(this.baseUrl + 'api/patients', patient);
  }

  getTestTypes(): Observable<TestType[]> {
    return this.http.get<TestType[]>(this.baseUrl + 'api/testtypes');
  }

  getTestResults(): Observable<TestResult[]> {
    return this.http.get<TestResult[]>(this.baseUrl + 'api/testresults');
  }

  getTestResultsByPatient(patientId: number): Observable<TestResult[]> {
    return this.http.get<TestResult[]>(this.baseUrl + `api/testresults/patient/${patientId}`);
  }

  createTestResult(result: TestResult): Observable<TestResult> {
    return this.http.post<TestResult>(this.baseUrl + 'api/testresults', result);
  }
}
