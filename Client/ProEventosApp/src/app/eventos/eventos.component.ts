import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import Evento from "./EventType";
@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {
  carregandoEventos = true;

  eventosFiltrados: Evento[] = []
  eventos: Evento[] = [];
  larguraImagem = 50;
  mostrarImagens = true;

  _filtro = "";



  public get filtro() {
    return this._filtro;
  };
  public set filtro(valor) {
    this._filtro = valor;
    this.eventosFiltrados = this.filtraEventos();
  };

  private filtraEventos() {
    return this.eventos.filter(e => {
      // deixa palavras do evento a serem filtradas em minusculo
      const tema = e.tema.toLowerCase();
      const local = e.local.toLowerCase();
      // deixa filtro em minusculo
      const filtro = this._filtro.toLowerCase();

      if (tema.includes(filtro) || local.includes(filtro)) return e;
      return;
    });
  }

  constructor(private http: HttpClient) {
  }

  ngOnInit(): void {
    this.GetEventos();
  }

  public GetEventos(): any {
    this.http.get("https://localhost:5000/api/evento").subscribe(
      response => {
        const novosEventos = response as Evento[];
        this.eventos = novosEventos;
        this.carregandoEventos = false;
        this.eventosFiltrados = this.filtraEventos();
      },
      error => {
        console.log(error);
        this.carregandoEventos = false;
      }
    );
  }
}
