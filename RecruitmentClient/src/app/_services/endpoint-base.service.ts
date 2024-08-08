import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

export class EndpointBaseService {
  constructor() {}

  protected get requestHeaders() {
    const token = localStorage.getItem('token');

    const headers = new HttpHeaders({
      'Authorization': 'Bearer ' + token,
      'Content-Type': 'application/json',
      'Accept': 'application/json, text/plain, */*',
    });

    return headers;
  }
}
