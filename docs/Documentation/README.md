# SmartFarm Website

Built using Jekyll.

You need to have Bundle and Jekyll installed:

```
gem install jekyll bundler
```

Clone this repository and `cd` into it and get dependencies:

```
bundle exec jekyll serve
```

To deploy to GitLab, just push on the `master` branch.
To deploy do `xcoa`:

```
git checkout deploy
git pull origin deploy
git merge master
```

After that, run Jekyll to generate new static files:

```
bundle exec jekyll serve
```

And copy to `xcoa` the `_site` folder to the `public_html` folder.
