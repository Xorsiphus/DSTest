import { Component } from '@angular/core';
import { WeatherService } from 'src/app/services/weather.service';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent {
  progress: number | null = null;
  files: File[] = [];

  constructor(private weatherService: WeatherService) { }

  onFileSelected(event: any) {
    this.files = [];
    this.progress = null;
    for (var i = 0; i < event.target.files.length; i++) {
      this.files.push(event.target.files[i]);
    }
  }

  uploadFile() {
    this.weatherService.uploadFile(this.files)
      .subscribe(progress => {
        this.progress = progress;
      });
  }
}
