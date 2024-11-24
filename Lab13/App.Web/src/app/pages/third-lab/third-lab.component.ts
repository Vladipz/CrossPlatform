import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApiService } from 'src/app/api.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-third-lab',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './third-lab.component.html',
  styleUrl: './third-lab.component.css',
})
export class ThirdLabComponent {
  inputText: string = '';
  outputResult: string | null = null;
  hasApiError: boolean = false;
  errorMessages: string = '';
  apiService = inject(ApiService);

  onSubmit() {
    console.log('Input:', this.inputText.trim());
    if (this.inputText.trim()) {
      this.apiService.solveLab('third', this.inputText).subscribe({
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
