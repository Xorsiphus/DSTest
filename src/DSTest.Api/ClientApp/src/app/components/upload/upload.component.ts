import { Component, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { WeatherService } from 'src/app/services/weather.service';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnDestroy {
  private dataSubscription: Subscription | undefined;
  progress: number | null = null;
  files: File[] = [];
  completed: number = 0;

  constructor(private weatherService: WeatherService) { }

  ngOnDestroy() {
    this.dataSubscription?.unsubscribe();
  }

  onFileSelected(event: any) {
    this.files = [];
    this.progress = null;
    this.completed = 0;
    for (var i = 0; i < event.target.files.length; i++) {
      this.files.push(event.target.files[i]);
    }
  }

  uploadFile() {
    this.dataSubscription = this.weatherService.uploadFile(this.files)
      .subscribe(progress => {
        this.progress = progress;
        if (progress == 100) this.completed += 1;
      });
  }
}
