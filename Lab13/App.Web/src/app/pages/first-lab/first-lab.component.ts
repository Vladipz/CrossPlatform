import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ApiService } from 'src/app/api.service';

@Component({
  selector: 'app-first-lab',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './first-lab.component.html',
  styleUrl: './first-lab.component.css',
})
export class FirstLabComponent {
  inputText: string = '';
  outputResult: string | null = null;
  hasApiError: boolean = false;
  errorMessages: string = '';
  apiService = inject(ApiService);

  onSubmit() {
    console.log('Input:', this.inputText.trim());
    if (this.inputText.trim()) {
      this.apiService.solveLab('first', this.inputText).subscribe({
        next: (res) => {
          this.hasApiError = false;
          this.outputResult = res.outputResult || 'Результат відсутній';
        },
        error: (err) => {
          console.error('Error:', err);
          this.hasApiError = true;
          this.errorMessages = 'Помилка при обробці запиту';
        },
      });
    } else {
      this.outputResult = 'Будь ласка, введіть правильні дані';
    }
  }
}
