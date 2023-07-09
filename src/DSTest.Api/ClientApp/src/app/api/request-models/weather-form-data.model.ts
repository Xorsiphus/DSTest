export class WeatherFormDataModel {
    public formData: FormData = new FormData();

    public AddFile(file: File) { this.formData.append("files", file); }
}