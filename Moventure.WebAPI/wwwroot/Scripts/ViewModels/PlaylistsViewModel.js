var PlaylistsViewModel = function () {
    var self = this;
    self.PlaylistListViewModel = ko.observableArray();

    self.init = function (data) {
        var playlistList = [];
        for (var i = 0; i < data.playlists.length; i++) {
            var currentPlaylist = new PlaylistMovieViewModel();
            currentPlaylist.init(data.playlists[i].id, data.playlists[i].name, data.playlists[i].movies);
            playlistList.push(currentPlaylist);
        }

        self.PlaylistListViewModel(playlistList);
    }
}
