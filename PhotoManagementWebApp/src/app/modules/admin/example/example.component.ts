import { Component } from '@angular/core';

@Component({
    selector     : 'example',
    templateUrl  : './example.component.html'
})
export class ExampleComponent
{
    text1: string = '<div>Hello World!</div><div>PrimeNG <b>Editor</b> Rocks</div><div><br></div>';
    text2: string;

    /**
     * Constructor
     */
    constructor()
    {
    }
}
