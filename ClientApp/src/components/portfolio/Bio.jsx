import React, { Component } from 'react';
import { Grid, Row } from 'react-bootstrap';

export class Bio extends Component {

    render() {
        return (
            <section id="me" className="bio-section global-padding">
                <Grid>
                    <Row>
                        <h2 className="text-center">About Me</h2>
                        <p className="b-underline"></p>
                    </Row>
                    <Row className="global-margin">
                        <img className="img-responsive bio-pic" src="../img/portfolio/prof_pic_2018.jpeg" />
                    </Row>
                    <Row>
                        <p className="text-center">Whats sparked my interest in coding was my love for technology. For several
                        years
                        now
                        I've been an
                        actively
                        involved tech enthusiast. it started with smartphones. My very first smartphone was the iPhone 3GS,
                        it was my first step into the newly arisen smartphone revolution. Currently I am interested in both
                        Android and
                        Apple devices and will interchange between platforms.
                        Not long after I began to develop love for all sorts of
                        technology and gadgets. After so long I decided that using and admiring tech wasn't enough for me
                        so I turned to something even better, programming. It became obvious to me that I wanted to develop
                        software for the devices I was so invested in. My first programming language was C#, as I was
                        learning
                        to develop in C# it felt like a whole new world of possibilities and that is what I absolutely
                        love
                        about programming, you can do most anything with it.
                        </p>
                    </Row>
                </Grid>
            </section>
        );
    }
}