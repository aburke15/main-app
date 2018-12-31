import React, { Component } from 'react';
import { Grid, Row, Col, Jumbotron, ListGroup, ListGroupItem } from 'react-bootstrap';

export class Project extends Component {
    constructor(props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            repos: []
        };
    }

    componentDidMount() {
        fetch('http://www.aburke.io/api/repo')
            .then(res => res.json())
            .then(
                (repos) => {
                    this.setState({
                        isLoaded: true,
                        repos: repos
                    });
                },
                (error) => {
                    this.setState({
                        isLoaded: true,
                        error
                    });
                }
            );
    }

    render() {
        const { error, isLoaded, repos } = this.state;
        if (error) {
            return <div>Error: {error.message}</div>;
        } else if (!isLoaded) {
            return <div className="text-center">Loading...</div>;
        } else {
            const secondColumnStart = Math.floor(repos.length / 2);
            return (
                <section id="projects" className="projects-section global-padding">
                    <Grid>
                        <Row>
                            <h2 className="text-center">Projects</h2>
                            <p className="b-underline"></p>
                        </Row>
                        <Row className="global-margin">
                            <Col md={6}>
                                {repos.slice(0, secondColumnStart).map(repo => (
                                    <Jumbotron key={repo.name}>
                                        <h3>{repo.name.toUpperCase()}</h3>
                                        <hr />
                                        <ListGroup>
                                            <ListGroupItem>Desc:&nbsp;{repo.description}</ListGroupItem>
                                            <ListGroupItem>Language:&nbsp;{repo.language}</ListGroupItem>
                                            <ListGroupItem>Forks:&nbsp;{repo.forks}</ListGroupItem>
                                            <ListGroupItem><a rel="noopener" target="_blank" href={repo.htmlUrl}>View in GitHub</a></ListGroupItem>
                                            <ListGroupItem>Created:&nbsp;{repo.createdAt}</ListGroupItem>
                                        </ListGroup>
                                    </Jumbotron>
                                ))}
                            </Col>
                            <Col md={6}>
                                {repos.slice(secondColumnStart).map(repo => (
                                    <Jumbotron key={repo.name}>
                                        <h3>{repo.name.toUpperCase()}</h3>
                                        <hr />
                                        <ListGroup>
                                            <ListGroupItem>Desc:&nbsp;{repo.description}</ListGroupItem>
                                            <ListGroupItem>Language:&nbsp;{repo.language}</ListGroupItem>
                                            <ListGroupItem>Forks:&nbsp;{repo.forks}</ListGroupItem>
                                            <ListGroupItem><a rel="noopener" target="_blank" href={repo.htmlUrl}>View in GitHub</a></ListGroupItem>
                                            <ListGroupItem>Created:&nbsp;{repo.createdAt}</ListGroupItem>
                                        </ListGroup>
                                    </Jumbotron>
                                ))}
                            </Col>
                        </Row>
                    </Grid>
                </section>
            );
        }
    }
}