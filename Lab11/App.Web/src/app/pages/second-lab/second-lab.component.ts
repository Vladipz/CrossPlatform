import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApiService } from 'src/app/api.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-second-lab',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './second-lab.component.html',
  styleUrl: './second-lab.component.css',
})
export class SecondLabComponent {
  inputText: string = '';
  outputResult: string | null = null;
  hasApiError: boolean = false;
  errorMessages: string = '';
  apiService = inject(ApiService);

  onSubmit() {
    console.log('Input:', this.inputText.trim());
    if (this.inputText.trim()) {
      this.apiService.solveLab('second', this.inputText).subscribe({
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
