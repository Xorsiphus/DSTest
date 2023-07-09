export class WeatherFormDataUploadModel {
    public formData: FormData = new FormData();

    public AddFile(file: File) { this.formData.append("files", file); }
}