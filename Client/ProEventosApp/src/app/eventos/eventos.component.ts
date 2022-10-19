import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  public eventos: any;
  constructor(private http: HttpClient) {
  }

  ngOnInit(): void {
    this.GetEventos();
  }

  public GetEventos(): any {
    this.http.get("https://localhost:5000/api/evento").subscribe(
      response => {
        this.eventos = response;
        console.log(response);
      },
      error => {
        console.log(error);
      }
    );
  }
}
