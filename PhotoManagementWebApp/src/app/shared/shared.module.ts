import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

//PrimeNG
import { EditorModule } from 'primeng/editor';
import { ButtonModule } from 'primeng/button'
import {TableModule} from 'primeng/table';

//Transloco
import { TranslocoModule } from '@ngneat/transloco';


@NgModule({
    imports: [

        EditorModule,
        ButtonModule,

        CommonModule,
        FormsModule,
        ReactiveFormsModule
    ],
    exports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        //PrimeNG
        EditorModule,
        ButtonModule,
        TableModule,


        TranslocoModule
    ]
})
export class SharedModule
{
}
