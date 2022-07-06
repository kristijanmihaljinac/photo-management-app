import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { EditorModule } from 'primeng/editor';
import { ButtonModule } from 'primeng/button'

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

        EditorModule,
        ButtonModule,
    ]
})
export class SharedModule
{
}
