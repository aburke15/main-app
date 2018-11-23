import React, { Component } from 'react';
import { Grid } from 'react-bootstrap';

export class Title extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <section className="title-section parallax">
                <Grid>
                    <h1 className="text-center title title-color">Andre Burke</h1>
                    <h2 className="text-center sub-title title-color">Software Engineer</h2>
                </Grid>
            </section>
        );
    }
}